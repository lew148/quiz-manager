import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { get } from '../../Api';

const Quiz = () => {
    const { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [quiz, setQuiz] = useState(null);

    useEffect(() => {
        const FetchData = async () => {
            const response = await get(`quiz/${id}`);
            setQuiz(response);
            setLoading(false);
        };
        FetchData();
    }, [id]);

    return (loading ? <p>Loading Quiz...</p>
        : (
            <div className="jumbotron">
                <h1>{quiz.name}</h1>
                <p>{quiz.description}</p>
                <hr className="my-4"></hr>
                <ol type="A">
                    {quiz.questions.map(question => (<>
                    <li>{question.description}</li>
                    <ol>
                        {question.answers.map(answer => (
                            <li>{answer.description}</li>
                        ))}
                    </ol>
                    </>))}
                </ol>
            </div>
        )
    );
};

export default Quiz;
