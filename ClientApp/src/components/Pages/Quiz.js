import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { get } from '../../Api';
import AddQuestionForm from '../Forms/AddQuestionForm';
import AddAnswerForm from '../Forms/AddAnswerForm';
import { DeleteButton } from '../Forms/InputTypes'

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
                <hr className="my-4"></hr>
                <div className="add-forms">
                    <AddQuestionForm
                        quizId={id}
                        numberOfQuestions={quiz.questions.length}
                    />
                    {(quiz.questions.length > 0) &&
                        <AddAnswerForm
                            quizId={id}
                            questions={quiz.questions}
                        />
                    }
                </div>
                <hr className="my-4"></hr>
                <ol type="1">
                    {sortByOrderNumber(quiz.questions).map(question => (<>
                        <div className="d-flex">
                            <div className="form-input-row">
                                <li><strong>{question.description}</strong></li>
                            </div>
                            <DeleteButton
                                confirmText="Are you sure you want to delete this question?"
                                apiDeleteRoute={`question/delete/${question.id}`}
                            />
                        </div>
                        <ol type="A">
                            {question.answers.map(answer => (
                                <div className="d-flex">
                                    <div className="form-input-row">
                                        <li key={answer.id}>{answer.description}</li>
                                    </div>
                                    {question.answers.length > 3 &&
                                        <DeleteButton
                                            confirmText="Are you sure you want to delete this answer?"
                                            apiDeleteRoute={`answer/delete/${answer.id}`}
                                        />
                                    }
                                </div>
                            ))}
                        </ol>
                    </>))}
                </ol>
            </div>
        )
    );
};

export default Quiz;
