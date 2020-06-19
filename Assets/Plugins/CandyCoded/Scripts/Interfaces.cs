// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

namespace CandyCoded.Interfaces
{

    public interface IPausable
    {

        void Pause();

        void Resume();

    }

    public interface IToggleable
    {

        void On();

        void Off();

    }

}
