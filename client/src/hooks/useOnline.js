import { useState, useEffect } from 'react';
const useOnline = () => {
  const [isOnline, setIsOnline] = useState(true)

  useEffect(() => {
    
    const handleOnLine = () => setIsOnline(true);
    const handleOffLine = () => setIsOnline(false);

    window.addEventListener("online", handleOnLine);
    window.addEventListener("offline", handleOffLine);

    // clean-up event listners
    return () => {
      window.removeEventListener("online", handleOnLine);
      window.removeEventListener("offline", handleOffLine);
    }

  },[])
  

  return isOnline;
}

export default useOnline;