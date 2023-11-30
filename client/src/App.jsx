import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [posts, setPosts] = useState([]);

  console.log(posts);

  useEffect(() => {
    fetch("http://localhost:5000/api/post")
      .then((res) => res.json())
      .then((data) => setPosts(data));
  }, []);

  // const renderPosts = (posts) => {
  //   return (
  //     <ul>
  //       {posts.map((post, index) => {
  //         <li key={index}>
  //           {post.name} - {post.title}{" "}
  //         </li>;
  //       })}
  //     </ul>
  //   );
  // };

  return (
    <div>
      <h1> Welcome to our Blog </h1>
      <ul>
        {posts.map(
          (
            post,
            index // when you return jsx directly use (), after =>
          ) => (
            <li key={index}>
              {post.name} - {post.title}
            </li>
          )
        )}
      </ul>
    </div>
  );
}

export default App;
