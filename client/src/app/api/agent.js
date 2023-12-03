import axios from "axios";
import { toast } from "react-toastify";
import { router } from "../router/routes";


axios.defaults.baseURL = 'http://localhost:5000/api/';

const responseBody = (response) => response.data; // response is a type of AxiosResponse(response.data)


// the use() fn returns a response both the success and/or failure
axios.interceptors.response.use(response => {
    return response // Promise succeeded, retunr response 
}, (error) => {
  const { data, status } = error.response;
  switch (status) {
    case 400: // both for BadReq and validation errors
      if (data.errors) {
        const modelStateErrors = [];
        for (const key in data.errors) {
          if (data.errors[key])
          {
            modelStateErrors.push(data.errors[key])
            }
        }
        throw modelStateErrors.flat();
      }
      toast.error(data.title);
      break;
    case 401:
      toast.error(data.title);
      break;
    case 500:
      router.navigate('/server-error', {state: {error:data}});
      break;
    default:
      break;
  }
  return Promise.reject(error.response); // Promise failed: returning error, not handling error, catching/handling error takes place inside each component 
  })

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