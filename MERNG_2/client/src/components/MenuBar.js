import React,{ useState } from 'react';
import { Menu } from 'semantic-ui-react';
import { Link } from 'react-router-dom'; //링크 역할을 하고 있다.
function MenuBar() {
    const pathname = window.location.pathname; //uri 주소로도 변경 먹히도록
    //const path  = pathname === '/' ? 'home' : pathname.substr(1);
    const path  = pathname === '/' ? 'home' : pathname === '/login' ? 'login' : pathname === '/register' ? 'register' : '';
    const [activeItem, setActiveItem ] = useState(path); 

    const handleItemClick = (e,{name}) => setActiveItem(name);


    return (
    //semantic ui에서 복붙 한 소스 수정 액티브
     
            <Menu className="ui secondary pointing menu" size="massive" color="teal">
                <Menu.Item 
                    name='home' 
                    active={activeItem === 'home'} 
                    onClick={handleItemClick} 
                    as={Link}
                    to="/"
                />
                
                <Menu.Menu position='right'>
                    <Menu.Item 
                        name='login'
                        active={activeItem === 'login'}
                        onClick={handleItemClick}
                        as={Link}
                        to="/login"
                    />
                    <Menu.Item 
                        name='register'
                        active={activeItem === 'register'}
                        onClick={handleItemClick}
                        as={Link}
                        to="/register"
                    />
                </Menu.Menu>
            </Menu>
            
       
    )
};

export default MenuBar;
