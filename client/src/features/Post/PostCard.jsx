/* eslint-disable react/prop-types */
/* eslint-disable react/jsx-no-undef */

import "./PostCard.css";

function PostCard({ post }) {
  console.log(" PostCard rendering ");

  return (
    <div className="card" key={post.postId}>
      <img
        className="card-image"
        src="https://placekitten.com/300/200"
        alt="Card"
      />
      <div className="card-content">
        <h2 className="card-title"> {post.title} </h2>
        <p className="card-text"> {post.name} </p>
        <p className="card-text"> {post.language} </p>
      </div>
    </div>
  );
}

export default PostCard;
