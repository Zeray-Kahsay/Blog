/* eslint-disable react/jsx-no-undef */
/* eslint-disable react/prop-types */
import PostCard from "./PostCard";
import "./PostList.css"

const PostList = ({ posts}) => {
  return (
    <div className="container" >
      {posts.map((post) => (
        <PostCard post={post} key={post.postId} />
      ))}
    </div>
  );
};

export default PostList;
