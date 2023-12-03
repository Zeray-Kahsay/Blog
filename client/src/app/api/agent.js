import axios from "axios";


axios.defaults.baseURL = 'http://localhost:5000/api/';

const responseBody = (response ) => response.data; // response is a type of AxiosResponse(response.data)

const requests = {
  get: (url) => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
  delete: (url) => axios.delete(url).then(responseBody),
}

const Catalog = {
  list: () => requests.get('post'),
  details: (id) => requests.get(`post/${id}`),
}

const TestErrors = {
  get400Error: () => requests.get('buggy/bad-request'),
  get401Error: () => requests.get('buggy/unauthorized'),
  get404Error: () => requests.get('buggy/not-found'),
  get500Error: () => requests.get('buggy/server-error'),
  getValidationError: () => requests.get('buggy/validation-error')
}

const agent = {
  Catalog,
  TestErrors
}

export default agent; 