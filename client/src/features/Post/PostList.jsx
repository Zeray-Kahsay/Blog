/* eslint-disable react/jsx-no-undef */
/* eslint-disable react/prop-types */
import PostCard from "./PostCard";

const PostList = ({ posts }) => {
  console.log("Post list loading");
  return (
    <div>
      {posts.map((post) => {
        <PostCard post={post} key={post.postId} />;
      })}
    </div>
  );
};

export default PostList;
