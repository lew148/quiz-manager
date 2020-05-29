import React from 'react';
import { useForm } from "react-form";
import { post } from '../../Api';
import { TextField, Select } from './InputTypes';

const convertFromIndexToOptionText = (num) => num + 1;

const constructQuestionOptions = (numberOfQuestions) => {
    var positions = [];
    for (var i = 0; i < numberOfQuestions; i++) {
        positions.push(i)
    }
    return positions.map(p => (
        {
            value: p,
            text: convertFromIndexToOptionText(p)
        })
    );
};

const handleSubmit = async (quizId, values) => {
    Object.assign(values, { quizId: quizId })
    await post("question/add", values);
    window.location.reload();
};

const AddQuestionForm = ({ quizId, numberOfQuestions }) => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            handleSubmit(quizId, values)
        },
    });

    return (
        <Form>
            <h5>Add Question</h5>
            <p className="text-muted">A question requires 3 initial answers, upon creation. You may add up to 5 after that.</p>
            <div className="d-flex">
                <div className="form-input-row" >
                    <TextField name="Question" type="text" />
                </div>
                {numberOfQuestions > 0 &&
                    <div className="form-input-row" >
                        <Select
                            field="orderPosition"
                            options={constructQuestionOptions(numberOfQuestions)}
                            description="Select position to enter question"
                            defaultValue={-1}
                            defaultText="Last"
                            className="number-select"
                        />
                    </div>
                }
                <div className="form-input-row" >
                    <TextField 
                        name="InitialAnswerOne"
                        type="text"
                        placeholder="First Answer"
                    />
                </div>
                <div className="form-input-row" >
                    <TextField 
                        name="InitialAnswerTwo"
                        type="text"
                        placeholder="Second Answer"
                    />
                </div>
                <div className="form-input-row" >
                    <TextField 
                        name="InitialAnswerThree"
                        type="text"
                        placeholder="Third Answer"
                    />
                </div>
                <button className="btn btn-primary btn-sm" type="submit">Add</button>
            </div>
        </Form>
    );
};

export default AddQuestionForm;