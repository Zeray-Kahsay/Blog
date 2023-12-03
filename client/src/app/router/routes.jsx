import { Navigate, createBrowserRouter } from "react-router-dom";
import About from "../layout/Header/About";
import Login from "../layout/Header/Login";
import Register from "../layout/Header/Register";
import PostDetails from "../../features/Post/PostDetails";
import App from "../layout/App";
import Catalog from "../../features/catalog/catalog";
import Contact from "../layout/Header/Contact";
import Projects from "../../features/Projects/Projects";
import Home from "../layout/Header/Home";
import Error from "../../features/Error/Error";
import ServerError from "../Errors/serverError";
import NotFound from "../Errors/notFound";


export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    errorElement: <Error />,
    children: [
      {path: 'catalog', element: <Catalog /> },
      { path: 'catalog/:id', element: <PostDetails /> },
      {path: 'home', element: <Home /> },
      {path: 'about', element: <About /> },
      {path: 'login', element: <Login /> },
      {path: 'register', element: <Register /> },
      {path: 'contact', element: <Contact /> },
      {path: 'projects', element: <Projects /> },
      {path: 'server-error', element: <ServerError /> },
      {path: 'not-found', element: <NotFound /> },
      {path: '*', element: <Navigate replace to='/not-found' /> }
    ]
  }
])