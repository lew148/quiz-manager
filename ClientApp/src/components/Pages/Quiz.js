import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { get } from '../../Api';
import AddQuestionForm from '../Forms/AddQuestionForm';

const sortByOrderNumber = (questions) => questions.sort((a, b) =>
    a.questionOrder.orderNumber - b.questionOrder.orderNumber);

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
                <AddQuestionForm
                    quizId={id}
                    numberOfQuestions={quiz.questions.length}
                />
                <hr className="my-4"></hr>
                <ol type="A">
                    {sortByOrderNumber(quiz.questions).map(question => (<>
                        <li><strong>{question.description}</strong></li>
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
