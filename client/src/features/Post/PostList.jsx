/* eslint-disable react/jsx-no-undef */
/* eslint-disable react/prop-types */
import PostCard from "./PostCard";
import "./PostList.css"

const PostList = ({ posts, onClick }) => {
  return (
    <div className="container" >
      {posts.map((post) => (
        <PostCard post={post} key={post.postId} onClick={onClick} />
      ))}
    </div>
  );
};

export default PostList;
