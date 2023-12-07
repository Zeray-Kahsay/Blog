import { useState } from "react";
import agent from "../../api/agent";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const navigate = useNavigate();
  // controlled form data
    const [formData, setFormData] = useState({
    email: '',
    password: ''
  });

   // handle change for the controlled form 
  const handleInputChange = (e) => {
    const { name, value } = e.target; // from dom element (e.target.name & e.target.value)
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    
    agent.Account.login(formData);

    navigate('/catalog');

    console.log('Form submitted:', formData);
  };

  //TODO: Validation
  return (
    <div className="registration-form-container">
      <form className="registration-form" onSubmit={handleSubmit}>
        <h2>Login</h2>
        <div className="form-group">
          <label htmlFor="email">Email</label>
          <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="password">Password</label>
          <input
            type="password"
            id="password"
            name="password"
            value={formData.password}
            onChange={handleInputChange}
            required
          />
        </div>
        <button type="submit">Login</button> 
      </form>
    </div>
  );
  
}

export default Login