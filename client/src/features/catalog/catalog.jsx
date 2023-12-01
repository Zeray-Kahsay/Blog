/* eslint-disable react/prop-types */

import PostList from "../Post/PostList";

const Catalog = ({ posts }) => {
  console.log("Catalog loading");
  return <PostList posts={posts} />;
};

export default Catalog;
