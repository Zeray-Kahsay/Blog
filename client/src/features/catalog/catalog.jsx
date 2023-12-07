//import axios from "axios";
import { useState, useEffect } from "react";
import agent from "../../app/api/agent";
import PostList from "../Post/PostList";
import SearchPost from "../Post/SearchPost";
import useOnline from "../../hooks/useOnline";

const Catalog = () => {
  const [posts, setPosts] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  
  // useEffect(() => {
  //   fetch("http://localhost:5000/api/post")
  //     .then((res) => res.json())
  //     .then((data) => setPosts(data));
  // }, []);

  //  useEffect(() => {
  //   axios.get("http://localhost:5000/api/post")
  //     .then(res => setPosts(res.data))
  //     .catch(err => console.log(err))
  //     .finally(() => setIsLoading(false));
  // }, [])

  useEffect(() => {
    agent.Catalog.list()
      .then(posts => setPosts(posts))
      .finally(() => setIsLoading(false))  ;
  }, [])

  
  // To know if a user is online or not 
  const isOnline = useOnline();
  if (!isOnline) {
    return <h1>⭕⭕ offline, please check your internet connection  </h1>
  }


  // const handleChange = () => {

  // }

  //TODO: make a custom shimmer for loading 

  if (isLoading) return <h3>Loading...</h3>
  if (!posts) return <h3>Problem fetching posts </h3>

  return (
    <>
      <SearchPost />
      < PostList posts = { posts }  />  
    </>
 );

};

export default Catalog;
