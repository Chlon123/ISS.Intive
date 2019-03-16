import * as React from 'react';
import linkedlogo from '../styles/images/linkedinlogo.png';
import gitlogo from '../styles/images/gitlogo.png';
import './Footer.css';

class Footer extends React.Component {
    public render() {
      return (
        <div className='footer-parent' id="#footer">
        <div className='image-parent'>
        <a href="https://www.linkedin.com/in/kchlon-in" target="_blank" rel="nofollow">
        <img src={linkedlogo} className='linkedLogo' id='#linkedLogo'/>
        </a>
        <a href="https://github.com/Chlon123/IIS.Intive" target="_blank" rel="nofollow">
        <img src={gitlogo} className='gitLogo' id='#gitLogo'/>
        </a>
        </div>
        </div>
      );
    }
  }

export default Footer;