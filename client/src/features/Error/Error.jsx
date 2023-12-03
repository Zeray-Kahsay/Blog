import { useRouteError } from "react-router-dom";

const Error = () => {
  const err = useRouteError();
  return (
    <>
    <div>Something went wrong...Oops!!</div>
    <h1> {err.StatusText || err.Error} </h1>
    </>
  )
}

export default Error;