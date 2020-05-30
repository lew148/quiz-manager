import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { get } from '../../Api';
import AddQuestionForm from '../Forms/AddQuestionForm';
import AddAnswerForm from '../Forms/AddAnswerForm';
import { DeleteButton } from '../Forms/InputTypes'
import EditForm from '../Forms/EditForm';

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
            <div className="jumbotron content-card">
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
                            questions={quiz.questions}
                        />
                    }
                </div>
                <hr className="my-4"></hr>
                <ol type="1">
                    {sortByOrderNumber(quiz.questions).map(question => (<>
                        <li key={question.id}>
                            <div className="d-flex">
                                <div className="form-input-row" >{question.description}</div>
                                <EditForm
                                    objectId={question.id}
                                    apiEditRoute="question/edit"
                                    placeholder="Edit Question"
                                />
                                <DeleteButton
                                    confirmText="Are you sure you want to delete this question?"
                                    apiDeleteRoute={`question/delete/${question.id}`}
                                />
                            </div>
                        </li>
                        <ol type="A">
                            {question.answers.map(answer => (
                                <li key={answer.id}>
                                    <div className="d-flex">
                                        <div className="form-input-row" >{answer.description}</div>
                                        <EditForm
                                            objectId={answer.id}
                                            apiEditRoute="answer/edit"
                                            placeholder="Edit Answer"
                                        />
                                        {question.answers.length > 3 &&
                                            <DeleteButton
                                                confirmText="Are you sure you want to delete this answer?"
                                                apiDeleteRoute={`answer/delete/${answer.id}`}
                                            />
                                        }
                                    </div>
                                </li>
                            ))}
                        </ol>
                    </>))}
                </ol>
            </div>
        )
    );
};

export default Quiz;
