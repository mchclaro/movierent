import './App.css';
import Client from "./pages/clients/Client";
import { Routes, Route } from 'react-router-dom';
import Movie from './pages/movies/Movie';
import Rent from './pages/rents/Rent';
import Home from './pages/home/Home';

export default function App() {

  return (
    <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/client/list' element={<Client />} />
        <Route path='/movie/list' element={<Movie />} />
        <Route path='/rent/list' element={<Rent />} />
    </Routes>
  );
}