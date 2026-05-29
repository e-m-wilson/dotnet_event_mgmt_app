import React from 'react'
import type { Activity } from '../../types'
import { Button, Card, CardActions, CardContent, Chip, Typography } from '@mui/material';

type Props = {
    activity: Activity;
    setSelectedActivity: (id: string) => void
}

function ActivityCard({activity, setSelectedActivity} : Props) {
  return (
    <Card>
        <CardContent>
            <Typography>{activity.title}</Typography>
            <Typography>{activity.id}</Typography>
        </CardContent>
        <CardActions>
            <Chip label={activity.category} variant='outlined'/>
            <Button onClick={() => setSelectedActivity(activity.id)}>View</Button>
        </CardActions>
    </Card>
  )
}

export default ActivityCard