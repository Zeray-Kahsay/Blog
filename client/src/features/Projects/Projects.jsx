import agent from "../../app/api/agent";


const Projects = () => {
  return (
    <div>
      <h2>Error handling for testing purposes</h2>
      <div>
        <button onClick={() => agent.TestErrors.get400Error().catch(error => console.log(error))}>Test 400 Error</button>
        <button onClick={() => agent.TestErrors.get401Error().catch(error => console.log(error))}>Test 401 Error</button>
        <button onClick={() => agent.TestErrors.get404Error().catch(error => console.log(error))}>Test 404 Error</button>
        <button onClick={() => agent.TestErrors.get500Error().catch(error => console.log(error))}>Test 500 Error</button>
        <button onClick={() => agent.TestErrors.getValidationError().catch(error => console.log(error))}>Test Validation  Error</button>
      </div>
    </div>
  )
}

export default Projects;