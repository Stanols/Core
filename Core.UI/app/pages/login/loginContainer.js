﻿import React from 'react';
import { connect } from 'react-redux';
import actions from '../../actions/actions';
import Login from './login';

const mapStateToProps = (state, ownProps) => {
	const { loginReducer } = state;
	const { authorizationData, authorizationError } = loginReducer;
	return {
		authorizationData,
		authorizationError
	};
}

const mapDispatchToProps = (dispatch, ownProps) => {
	return {
		onSignIn: (data) => {
			dispatch({
				type: actions.USER_LOGIN,
				data: data
			});
		}
	};
}

export default connect(mapStateToProps, mapDispatchToProps)(Login);