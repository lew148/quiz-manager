import React from 'react';
import { useForm } from "react-form";
import { post } from '../../Api';
import { TextField, Select } from './InputTypes';

const convertNumberToLetter = (num) => String.fromCharCode(97 + num).toUpperCase();

const constructQuestionOptions = (numberOfQuestions) => {
    var positions = [];
    for (var i = 0; i < numberOfQuestions; i++) {
        positions.push(i)
    }
    return positions.map(p => (
        {
            value: p,
            text: convertNumberToLetter(p)
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
                        />
                    </div>
                }
                <button className="btn btn-primary btn-sm" type="submit">Add</button>
            </div>
        </Form>
    );
};

export default AddQuestionForm;