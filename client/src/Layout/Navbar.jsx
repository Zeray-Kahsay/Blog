import "./Navbar.css";
import { useState } from "react";

const Navbar = () => {
  const [isMenuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!isMenuOpen);
  };

  return (
    <div className="navbar">
      <div className="navbar-logo">Your Logo</div>
      <div className={`navbar-links ${isMenuOpen ? "active" : ""}`}>
        <a href="#">Home</a>
        <a href="#">About</a>
        <a href="#">Services</a>
        <a href="#">Contact</a>
      </div>
      <div className="navbar-toggle" onClick={toggleMenu}>
        <div className={`bar ${isMenuOpen ? "bar1" : ""}`}></div>
        <div className={`bar ${isMenuOpen ? "bar2" : ""}`}></div>
        <div className={`bar ${isMenuOpen ? "bar3" : ""}`}></div>
      </div>
    </div>
  );
};

export default Navbar;
