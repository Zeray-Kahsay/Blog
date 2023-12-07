
import { useState } from 'react'
import { NavLink } from 'react-router-dom'
//import { ReactComponent as Hamburger } from '../../assets/icons/hamburger.svg'
//import { ReactComponent as Brand } from '../../assets/icons/logo.svg'
import './Navbar.css'

const Navbar = () => {
  const [showNavbar, setShowNavbar] = useState(false)

  const handleShowNavbar = () => {
    setShowNavbar(!showNavbar)
  }

  return (
    <nav className="navbar">
      <div className="container">
        <div className="logo">
          {/* <Brand /> */}
        </div>
        <div className="menu-icon" onClick={handleShowNavbar}>
          {/* <Hamburger /> */}
        </div>
        <div className={`nav-elements  ${showNavbar && 'active'}`}>
          <ul>
            <li>
              <NavLink to="/home">Home</NavLink>
            </li>
            <li>
              <NavLink to="/catalog">Catalog</NavLink>
            </li>
            <li>
              <NavLink to="/about">New Content </NavLink>
            </li>
            <li>
              <NavLink to="/projects">Projects</NavLink>
            </li>
            <li>
              <NavLink to="/login">Login</NavLink>
            </li>
            <li>
              <NavLink to="/register">Register</NavLink>
            </li>
            <li>
              <NavLink to="/contact">Contact us</NavLink>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  )
}

export default Navbar;


  //TODO: mobile 
  // return (
  //   <div className="navbar">
  //     <div className="navbar-logo">Logo</div>
  //     <div className={`navbar-links ${isMenuOpen ? "active" : ""}`}>
  //       <a href="#">Home</a>
  //       <a href="#">About</a>
  //       <a href="#">Services</a>
  //       <a href="#">Contact</a>
  //     </div>
  //     <div className="navbar-toggle" onClick={toggleMenu}>
  //       <div className={`bar ${isMenuOpen ? "bar1" : ""}`}></div>
  //       <div className={`bar ${isMenuOpen ? "bar2" : ""}`}></div>
  //       <div className={`bar ${isMenuOpen ? "bar3" : ""}`}></div>
  //     </div>
  //   </div>
  // );
