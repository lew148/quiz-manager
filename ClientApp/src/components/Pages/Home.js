import React, { useState, useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import { get } from '../../Api';

const Home = ({ history }) => {
  const [loading, setLoading] = useState(true);
  const [quizzes, setQuizzes] = useState(null);

  useEffect(() => {
    const FetchData = async () => {
      const response = await get('quiz/all');
      setQuizzes(response);
      setLoading(false);
    };
    FetchData();
  }, []);

  const handleButtonClick = (id) => () => {
    history.push(`/quiz/${id}`)
  }

  return (loading ? <div>Loading...</div>
  : quizzes.map(q => (
    <div className="card m-3">
      <div className="card-body">
        <h5 className="card-title">{q.name}</h5>
        <p className="card-text">{q.description}</p>
        <button type="button" onClick={handleButtonClick(q.id)} className="btn btn-primary btn-lg btn-block">View</button>
      </div>
    </div>
  )));
};

export default withRouter(Home);
