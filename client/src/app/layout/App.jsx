import "./styles.css";
import Navbar from "../../Layout/Navbar";
import { Outlet } from "react-router-dom";
import Footer from "./Footer/Footer";

function App() {

  return (
    <>
      <Navbar />
      <div>
        <Outlet /> 
      </div>
      <Footer /> 
    </>
  );
}

export default App;
