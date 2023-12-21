// App.jsx
import {BrowserRouter,Routes,Route} from 'react-router-dom';
import Home from './pages/Home'
import Casussen from './pages/Casussen'
import Login from './pages/Login'
import Register from './pages/Register'

export default function App() {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route index element={<Home/>} />
                    <Route path="/home" element={<Home/>} />
                    <Route path="/casussen" element={<Casussen/>} />
                    <Route path="/login" element={<Login/>} />
                    <Route path="/register" element={<Register/>} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}