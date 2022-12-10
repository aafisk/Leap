using Raylib_cs;
using Keyboard;
using Constant;

public class MoveActors
{
    private KeyboardService keyboardService = new KeyboardService();
    private Player player1;
    private Player player2;

    public MoveActors(Player p1, Player p2)
    {
        player1 = p1;
        player2 = p2;
    }
    
    public void Execute(){

        // Player 1 controls
        if (keyboardService.IsKeyUp("a"))
        {
            player1.SetVelocity(0, player1.GetVelocity().GetY());
        }

        if (keyboardService.IsKeyUp("d"))
        {
            player1.SetVelocity(0, player1.GetVelocity().GetY());
        }

        // Left
        if (keyboardService.IsKeyDown("a"))
        {
            player1.SetVelocity(-7, player1.GetVelocity().GetY());
        }

        // Right
        if (keyboardService.IsKeyDown("d"))
        {
            player1.SetVelocity(7, player1.GetVelocity().GetY());
        }

        // Jump
        if (player1.IsAirborne())
        {
            player1.SetVelocity(player1.GetVelocity().GetX(), player1.GetVelocity().GetY() + Constants.FALL_SPEED);
        } 
        else if (!player1.IsAirborne())
        {
            player1.SetVelocity(player1.GetVelocity().GetX(), 0);

            if (keyboardService.IsKeyDown("w"))
            {
                player1.SetVelocity(player1.GetVelocity().GetX(), Constants.JUMP_HEIGHT);
            }
        }


        // Add velocity to current position
        player1.SetPosition(new Point(player1.GetPosition().GetX() + player1.GetVelocity().GetX(), 
                            player1.GetPosition().GetY() + player1.GetVelocity().GetY()));

        // Player 2 controls
        if (keyboardService.IsKeyUp("left"))
        {
            player2.SetVelocity(0, player2.GetVelocity().GetY());
        }

        if (keyboardService.IsKeyUp("right"))
        {
            player2.SetVelocity(0, player2.GetVelocity().GetY());
        }

        // Left
        if (keyboardService.IsKeyDown("left"))
        {
            player2.SetVelocity(-7, player2.GetVelocity().GetY());
        }

        // Right
        if (keyboardService.IsKeyDown("right"))
        {
            player2.SetVelocity(7, player2.GetVelocity().GetY());
        }

        // Jump
        if (player2.IsAirborne())
        {
            player2.SetVelocity(player2.GetVelocity().GetX(), player2.GetVelocity().GetY() + Constants.FALL_SPEED);
        } 
        else if (!player2.IsAirborne())
        {
            player2.SetVelocity(player2.GetVelocity().GetX(), 0);
            if (keyboardService.IsKeyDown("up"))
            {
                player2.SetVelocity(player2.GetVelocity().GetX(), Constants.JUMP_HEIGHT);
            }
        }

        // Add velocity to current position
        player2.SetPosition(new Point(player2.GetPosition().GetX() + player2.GetVelocity().GetX(), 
                            player2.GetPosition().GetY() + player2.GetVelocity().GetY()));
    }


}