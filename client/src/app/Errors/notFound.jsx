import { useNavigate } from "react-router-dom"

const NotFound = () => {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate('/catalog');
  }
  
  return (
    <div className="not-found">
      <h2>Oops - we could not find what you are looking for</h2>
      <hr />
      <button onClick={ handleClick}>Go back to catalog</button>
    </div>
  )
}

export default NotFound;