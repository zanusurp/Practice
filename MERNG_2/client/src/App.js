
import React from 'react';
import {BrowserRouter as Router, Route} from 'react-router-dom';
import { Container } from 'semantic-ui-react';//전체를 둘러주기 위한 것 (모서리부분들 틈줌)

import 'semantic-ui-css/semantic.min.css';
import './App.css';

import MenuBar from './components/MenuBar';//semanctic에서 메뉴 파트 복사한 것 불러오기
import Home from'./pages/Home';
import Login from'./pages/Login';
import Register from'./pages/Register';

function App() {
  return (
    <Router>
      <Container> {/* div className="ui container" 대신 이렇게 */}
        <MenuBar />
        <Route exact path='/' component={Home} />
        <Route exact path="/login" component={Login}/>
        <Route exact path="/register" component={Register}/>
      </Container>
    </Router>
  );
}

export default App;
