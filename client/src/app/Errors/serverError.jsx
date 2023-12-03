import { useLocation } from "react-router-dom";

const ServerError = () => {
  const { state } = useLocation();
  return (
    <div>
      {state?.error ? (
        <>
          <h2>{state.error.title} </h2>
          <hr />
          <div>
            {state.error.detail || 'Internal server error'}
          </div>
        </>
      ) : (
         <h2>Server error </h2>
      )}
    </div>
  )
}

export default ServerError;