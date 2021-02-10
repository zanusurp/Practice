import React from 'react';
import { Form, Button } from 'semantic-ui-react';
import gql from 'graphql-tag';
import { useForm } from '../util/hooks';
import { ValuesOfCorrectTypeRule } from 'graphql';

import { useMutation } from '@apollo/client';
import { FETCH_POSTS_QUERY } from '../util/graphql';
function PostForm() {
    const { values, onchange, onSubmit } = useForm(createPostCallback, {
        body:''
    });

    const [ createPost, { error }] = useMutation(CREATE_POST_MUTATION, {
        variables: values,
        update(proxy,result){
            const data = proxy.readQuery({
                query: FETCH_POSTS_QUERY
            })
            data.getPosts = [result.data.getPost, ...data.getPosts];
            proxy.writeQuery({query: FETCH_POSTS_QUERY,data});
            values.body = ''
        }
    });

    function createPostCallback(){
        createPost();
    }

    return (
        <Form onSubmit= {onSubmit}>
            <h2>Create a Post : </h2>
            <Form.Field>
                <Form.Input placeholder ='Hi Worl' name='body' 
                    onChange={onchange} value={values} />
                <Button type='submit' color='teal'>
                    submit
                </Button>
                
            </Form.Field>
        </Form>
    )
}

const CREATE_POST_MUTATION = gql`
mutation createPost($body:String!){
    createPost(body:$body){
        id body createdAt username 
        likes{
            id username createdAt
        }
        likeCount
        comments{
            id body username createdAt
        }
        commentCount
    }
}
`

export default PostForm;
