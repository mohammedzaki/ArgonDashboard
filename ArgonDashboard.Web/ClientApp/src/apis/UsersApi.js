import BaseApi from './BaseApi';

export default class UsersApi extends BaseApi {
    async login(username, password) {
        let userData = {
            username,
            password
        };
        return await this.postData('auth/login', userData);
    }
}