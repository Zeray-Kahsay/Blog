import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import Navbar from "../../Layout/Navbar";
import { Outlet } from "react-router-dom";

function App() {

  return (
    <>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored"/> 
      <Navbar />
      <div>
        <Outlet /> 
      </div>
     
    </>
  );
}

export default App;
