import React from 'react'
import { Button, Card, Icon, Label,Image } from 'semantic-ui-react';
import { Link } from 'react-router-dom'; // 포스트 눌렀을 시에 그 아이디로 이동시키기 
import moment from 'moment';

function PostCard(/*props*/{ post : { body, createdAt, id, username, likeCount, commentCount, likes }}) {
    //const { body, createdAt, id, username, likeCount, commentCount, likes } = props.post
    /* 이미지 안되면 이걸로라도 바꿔야지뭐..  https://i.stack.imgur.com/WrKOj.png */
    function likePost(){
        console.log('like Post! ');
    }
    function commentOnPost(){
        console.log('comment on post');
    }
    return (
    
        <Card fluid>
            <Card.Content>
                <Image size='mini' floated='right' src='https://i.stack.imgur.com/WrKOj.png'  /> 
                <Card.Header>{username}</Card.Header>
                <Card.Meta as={Link} to={`/posts/${id}`}>{moment(createdAt).fromNow(true)}</Card.Meta>
                <Card.Description>{body}</Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button as='div' labelPosition='right' onClick={likePost}>
                    <Button color='teal' basic>
                        <Icon name='heart' />
                    </Button>
                    <Label as='a' basic color='teal' pointing='left'>
                        {likeCount}
                    </Label>
                </Button>
                <Button as='div' labelPosition='right' onClick={commentOnPost}>
                    <Button color='blue' basic>
                        <Icon name='comments' />
                    </Button>
                    <Label as='a' basic color='blue' pointing='left'>
                        {commentCount}
                    </Label>
                </Button>
                
            </Card.Content>
        </Card>
    );
}

export default PostCard;
