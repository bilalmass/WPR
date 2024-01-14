import axios from 'axios'
import foto from './images/icon_accessibility.png';

const AuthPage = (props) => {
    const onSubmit = (e) => {
      e.preventDefault();
      const { value } = e.target[0];
      axios.post(
        'http://localhost:3002/authenticate',
        {username: value}
      )
      .then(r => props.onAuth({ ...r.data, secret: value}))
      .catch(e => console.log('error', e))
    
    };
  
    return (
      <div className="background">
        <form onSubmit={onSubmit} className="form-card">
          <div className="form-title">Stichting Accessibility Chat <img src= {foto} height= "50" /> </div>
  
          <div className="form-subtitle">Type you naam in</div>
  
          <div className="auth">
            <div className="auth-label">Gebruiksnaam</div>
            <input className="auth-input" name="username" />
            <button className="auth-button" type="submit">
              Enter
            </button>
          </div>
        </form>
      </div>
    );
  };
  
  export default AuthPage;