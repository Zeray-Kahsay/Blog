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

  const handleClick = () => {
    console.log("Card clicked!")
  }

  return (
    <>
      <Navbar />

      <div>
        <Catalog posts={posts} onClick ={handleClick} />
      </div>
    </>
  );
}

export default App;
