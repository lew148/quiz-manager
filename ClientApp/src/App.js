import React, { useState, useEffect } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout/Layout';
import Home from './components/Pages/Home';
import Quiz from './components/Pages/Quiz';
import { get } from './Api';
import LoginForm from './components/Forms/LoginForm';

import './custom.css'

const App = () => {
  const [loading, setLoading] = useState(true);
  const [session, setSession] = useState(null);

  useEffect(() => {
    const FetchData = async () => {
      const response = await get('session');
      setSession(response);
      setLoading(false);
    };
    FetchData();
  }, []);

  return (loading ? <div>Loading...</div> :
    session != null && session.id ? (
      <Layout>
        <Route exact path='/' component={() => <Home permission={session.permission} />} />
        <Route path='/quiz/:id' component={() => <Quiz permission={session.permission} />} />
      </Layout>
    ) : <LoginForm />
  );
};

export default App;
