import "./Navbar.css";

const Navbar = () => {
  //const [isMenuOpen, setMenuOpen] = useState(false);

  // const toggleMenu = () => {
  //   setMenuOpen(!isMenuOpen);
  // };

  return (
    <div className="navbar">
      <div className="navbar-links">
        <a href="#">Logo</a>
        <a href="#">Home</a>
        <a href="#">About</a>
        <a href="#">Services</a>
        <a href="#">Contact</a>
      </div>
     
    </div>
  );
};

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
