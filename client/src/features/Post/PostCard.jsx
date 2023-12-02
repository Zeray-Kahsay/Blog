/* eslint-disable react/prop-types */
/* eslint-disable react/jsx-no-undef */

import "./PostCard.css";

function PostCard({ post, onClick }) {


  return (
   
    <div className="card" key={post.postId} onClick={onClick}>
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
