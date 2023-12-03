import { useNavigate } from "react-router-dom";
import "./PostCard.css";

function PostCard({ post }) {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/catalog/${post.postId}`)
  }

  return (
   
    <div className="card" key={post.postId} onClick={handleClick} >
      <img
        className="card-image"
        src="https://placekitten.com/500/300"
        alt="Card"
      />
      <div className="card-content">
        <h2 className="card-title"> {post.title} </h2>
        <p className="card-text"> {post.name} </p>
      </div>
    </div>

   
  );
}

export default PostCard;
