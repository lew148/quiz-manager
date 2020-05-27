import React, { useState, useEffect } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { get } from './Api';
import Login from './components/Forms/Login';

import './custom.css'

const App = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [session, setSession] = useState(null);

  useEffect(() => {
    const FetchData = async () => {
      const response = await get('session');
      setSession(response);
      setIsLoading(false);
    };
    FetchData();
  }, []);

  return (isLoading ? <div>Loading...</div> :
    session != null && session.loggedIn ? (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    ) : <Login />
  );
};

export default App;
