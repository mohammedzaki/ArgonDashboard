import BaseApi from './BaseApi';

export default class DepartmentApi extends BaseApi {
    async getAll() {
        return await this.getData('departments');
    }
    postData() { }
}