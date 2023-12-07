//import axios from "axios";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import NotFound from "../../app/Errors/notFound";

const PostDetails = () => {
  const params = useParams(); // reads id param from Url. NB: data from url is always string 
  const { id } = params; 
  // or const {id} = useParams(); destructuring on the fly
  const [postContent, setPostContent] = useState(null);
  const [laoding, setLoading] = useState(true);


  // useEffect( () => {
  //   fetch(`http://localhost:5000/api/post/${id}`)
  //       .then(res => res.json())
  //       .then(data => setPostContent(data));
  // }, [id])

  // useEffect(() => {
  //   axios.get(`http://localhost:5000/api/post/${id}`)
  //     .then(res => setPostContent(res.data))
  //     .catch(err => console.log(err))
  //     .finally(() => setLoading(false));
  // }, [id])

  useEffect(() => {
    agent.Catalog.details(parseInt(id))
      .then(response => setPostContent(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id])


  if (laoding) return <h3>Loading...</h3>

  //if (postContent == null) return <NotFound /> 
  
  return !postContent ? (
    <NotFound /> 
  ) : (
    <>
      <h1> {postContent.name} </h1>
      <div> {postContent.content} </div>   
    </>
  )
}

export default PostDetails;