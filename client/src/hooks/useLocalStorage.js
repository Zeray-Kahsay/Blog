import { useState } from 'react';

const useLocalStorage = (key, initialValue) => {
  // Get data from localstorage on initial render 
  const storedValue = localStorage.getItem(key);
  const initial = storedValue ? JSON.parse(storedValue) : initialValue;

  // State to hold the current value
  const [value, setValue] = useState(initial);

  // Update localstorage when the value changes 
  const setStoredValue = (newValue) => {
    setValue(newValue);
    localStorage.setItem(key, JSON.stringify(newValue));
  }

  return [value, setStoredValue]
  
}

export default useLocalStorage;
