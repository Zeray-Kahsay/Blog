import { useState } from 'react';
import "./SearchPost.css";


const SearchPost = () => {
  const [searchTerm, setSearchTerm] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

   console.log(searchTerm); 

  }

  const handleInputChange = (e) => {
    const searchTerm = e.target.value;
    setSearchTerm(searchTerm);

    
  }


  return (
    <form className="search" onSubmit={handleSubmit} >
      <input
        type="text"
        id="input-search"
        name="text"
        placeholder="Search (Ex.React )"
        value={searchTerm || ''}
        onChange={handleInputChange}
      />
      <button type="submit" id="search-btn" >Search</button>
      </form>
  )
}

export default SearchPost;