import React from 'react';
import { useForm } from "react-form";
import { post } from '../../Api';
import { TextField, AddButton } from './InputTypes';

const handleSubmit = async (values) => {
    await post("quiz/add", values);
    window.location.reload();
};

const AddAnswerForm = ({ questions }) => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            handleSubmit(values)
        },
    });

    return (
        <Form>
            <div className="card m-3">
                <div className="card-body content-card">
                    <h4 className="card-title">Add Quiz</h4>
                    <p className="text-muted">Add a blank quiz. You can add questions/answers to a quiz if you click the "view" button</p>
                    <div className="d-flex">
                        <div className="form-input-row" >
                            <TextField name="name" type="text" placeholder="Quiz Name" />
                        </div>
                        <div className="form-input-row" >
                            <TextField name="description" type="text" placeholder="Description" />
                        </div>
                        <AddButton />
                    </div>
                </div>
            </div>
        </Form>
    );
};

export default AddAnswerForm;