import { useEffect, useState } from "react";

import "./styles.css";
import Navbar from "../../Layout/Navbar";
import Catalog from "../../features/catalog/catalog";

function App() {
  const [posts, setPosts] = useState([]);

  console.log(posts);

  useEffect(() => {
    fetch("http://localhost:5000/api/post")
      .then((res) => res.json())
      .then((data) => setPosts(data));
  }, []);

  return (
    <>
      <Navbar />

      <div>
        <h1> Welcome to our Blog </h1>
        <Catalog posts={posts} />
        <h2> I miss something here </h2>
      </div>
    </>
  );
}

export default App;
