import { useState } from "react"; 
import "./about.css";
import agent from "../../api/agent"; 


const About = () => {
  const [formData, setFormData ]  =  useState({
    name: '',
    title: '',
    content: '',
    language: ''
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target; 
    setFormData({...formData, [name]: value})
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    agent.Post.create(formData)
    
    console.log('Form submitted!:', formData)
  }

  return (
    <form className="form-control" onSubmit={handleSubmit} >
      <div className="control-group">
        <label htmlFor="name">Name (Ex. Javascript)</label>
        <input
          type="text"
          name="name"
          id="name"
          onChange={handleInputChange}
        />
      </div>
      <div className="control-group">
        <label htmlFor="title">Title</label>
        <input
          type="title"
          name="title"
          id="title"
          onChange={handleInputChange}
        />
      </div>
       <div className="control-group">
        <label htmlFor="language">Language</label>
        <input
          type="text"
          name="language"
          id="language"
          onChange={handleInputChange}
        />
      </div>
      <div className="text-area">
         <label htmlFor="content">Content</label>
        <textarea
          name="content"
          id="content"
          rows={20}
          cols={150}
          onChange={handleInputChange}
        />
      </div>
      <div className="btn">
          <button type="submit">Submit Content </button>
      </div>
    </form>
  )
}

export default About;