import React, { useState, useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import { get } from '../../Api';
import AddQuizForm from '../Forms/AddQuizForm';
import { DeleteButton } from '../Forms/InputTypes';
import { Permissions } from '../../shared/Constants';

const Home = ({ history, permission }) => {
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
    : <div>
      {permission === Permissions.Edit &&
        <AddQuizForm />
      }
      <hr className="my-4"></hr>
      {quizzes.map(q => (
        <div className="card m-3">
          <div className="card-body content-card">
            <div className="d-flex">
              <h5 className="card-title quiz-title">{q.name}</h5>
              {permission === Permissions.Edit &&
                <DeleteButton
                  confirmText="Are you sure you want to delete this quiz?"
                  apiDeleteRoute={`quiz/delete/${q.id}`}
                />
              }
            </div>
            <hr className="my-4"></hr>
            <p className="card-text">{q.description}</p>
            <button type="button" onClick={handleButtonClick(q.id)} className="btn btn-primary btn-lg btn-block">View</button>
          </div>
        </div>
      ))}
    </div>
  );
};

export default withRouter(Home);
