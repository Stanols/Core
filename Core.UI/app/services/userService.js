﻿import BaseService from './baseService';

class UserService extends BaseService {
	constructor() {
		super('User');
	}

	async authenticate(requestData) {
		const response = await this.api.post(`${this.basePath}/Authenticate`, requestData);
		const { data } = response;
		const { token } = response;

		this.api.defaults.headers.common['Authorization'] = `Bearer ${token}`;

		return data;
	}

	async logout(requestData) {
		const response = await this.api.post(`${this.basePath}/Logout`, requestData);
		const { data } = response;

		return data;
	}
}

export default UserService;