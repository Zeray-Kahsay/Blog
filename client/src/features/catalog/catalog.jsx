/* eslint-disable react/prop-types */

import PostList from "../Post/PostList";

const Catalog = ({ posts, onClick }) => {
  console.log("Catalog loading");
  return <PostList posts={posts}  onClick={onClick}/>;
};

export default Catalog;
