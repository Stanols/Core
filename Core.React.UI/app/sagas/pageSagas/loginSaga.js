﻿import { all, call, put, takeEvery, takeLatest } from 'redux-saga/effects';
import actions from '../../actions/actions';
import loginActions from '../../actions/reducerActions/loginActions';
import UserService from "../../services/userService";
import AuthorizationHelper from 'app/helpers/authorizationHelper';

export function* loginSaga(dispatch) {
	yield all([
		takeLatest(actions.USER_RESTORE_AUTHORIZATION_DATA, async action => {
			if (AuthorizationHelper.isAuthorized()) {
				const authorizationData = AuthorizationHelper.getAuthorizationData();
				dispatch({ type: loginActions.LOGIN_USER_SUCCESS, data: authorizationData });
			} else {
				const error = "Not authorized error";
				dispatch({ type: loginActions.LOGIN_USER_FAILURE, data: error });
			}
		}),
		takeLatest(actions.USER_LOGIN, async action => {
			try {
				const userService = new UserService();
				const data = await userService.login(action.data);

				if (data) {
					AuthorizationHelper.setAuthorizationData(data);
				} else {
					AuthorizationHelper.removeAuthorizationData();
					throw new Error("Authentication failed");
				}
				dispatch({ type: loginActions.LOGIN_USER_SUCCESS, data });
			} catch (error) {
				AuthorizationHelper.removeAuthorizationData();
				dispatch({
					type: loginActions.LOGIN_USER_FAILURE,
					data: error
				});
			}
		}),
		takeEvery(actions.USER_LOGOUT, async (action) => {
			try {
				const userService = new UserService();
				await userService.logout();
				AuthorizationHelper.removeAuthorizationData();
				dispatch({ type: loginActions.LOGOUT_USER_SUCCESS });
			} catch (error) {
				dispatch({
					type: loginActions.LOGOUT_USER_FAILURE,
					data: error
				});
			}
		})
	]); 
}