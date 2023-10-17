/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * Copyright (c) 2017-2018 Swan & The Quaver Team <support@quavergame.com>.
*/

using Quaver.API.Maps.Processors.Difficulty.Optimization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quaver.API.Maps.Processors.Difficulty.Rulesets.Keys
{
    public class StrainConstantsKeys : StrainConstants
    {
        /// <summary>
        ///     When Long Notes start/end after this threshold, it will be considered for a specific multiplier.
        ///     Non-Dyanmic Constant. Do not use for optimization.
        /// </summary>
        public float LnEndThresholdMs { get; set; } = 42;

        /// <summary>
        ///     When seperate notes are under this threshold, it will count as a chord.
        ///     Non-Dyanmic Constant. Do not use for optimization.
        /// </summary>
        public float ChordClumpToleranceMs { get; set; } = 8;

        /// <summary>
        ///     Size of each graph partition in miliseconds.
        ///     Non-Dyanmic Constant. Do not use for optimization.
        /// </summary>
        public int GraphIntervalSizeMs { get; set; } = 500;

        /// <summary>
        ///     Offset between each graph partition in miliseconds.
        ///     Non-Dyanmic Constant. Do not use for optimization.
        /// </summary>
        public int GraphIntervalOffsetMs { get; set; } = 100;

        // Simple Jacks
        public float SJackLowerBoundaryMs { get; private set; }
        public float SJackUpperBoundaryMs { get; private set; }
        public float SJackMaxStrainValue { get; private set; }
        public float SJackCurveExponential { get; private set; }

        // Tech Jacks
        public float TJackLowerBoundaryMs { get; private set; }
        public float TJackUpperBoundaryMs { get; private set; }
        public float TJackMaxStrainValue { get; private set; }
        public float TJackCurveExponential { get; private set; }

        // Trills
        public float TrillLowerBoundaryMs { get; private set; }
        public float TrillUpperBoundaryMs { get; private set; }
        public float TrillMaxStrainValue { get; private set; }
        public float TrillCurveExponential { get; private set; }

        // Jumps
        public float JumpLowerBoundaryMs { get; private set; }
        public float JumpUpperBoundaryMs { get; private set; }
        public float JumpMaxStrainValue { get; private set; }
        public float JumpCurveExponential { get; private set; }

        // Hands
        public float HandLowerBoundaryMs { get; private set; }
        public float HandUpperBoundaryMs { get; private set; }
        public float HandMaxStrainValue { get; private set; }
        public float HandCurveExponential { get; private set; }

        // Quads
        public float QuadLowerBoundaryMs { get; private set; }
        public float QuadUpperBoundaryMs { get; private set; }
        public float QuadMaxStrainValue { get; private set; }
        public float QuadCurveExponential { get; private set; }

        // Rolls
        public float RollLowerBoundaryMs { get; private set; }
        public float RollUpperBoundaryMs { get; private set; }
        public float RollMaxStrainValue { get; private set; }
        public float RollCurveExponential { get; private set; }

        // Brackets
        public float BracketLowerBoundaryMs { get; private set; }
        public float BracketUpperBoundaryMs { get; private set; }
        public float BracketMaxStrainValue { get; private set; }
        public float BracketCurveExponential { get; private set; }

        // LN
        public float LnBaseMultiplier { get; private set; }
        public float LnLayerToleranceMs { get; private set; }
        public float LnLayerThresholdMs { get; private set; }
        public float LnReleaseAfterMultiplier { get; private set; }
        public float LnReleaseBeforeMultiplier { get; private set; }
        public float LnTapMultiplier { get; private set; }

        // LongJack Manipulation
        public float VibroActionDurationMs { get; set; }
        public float VibroActionToleranceMs { get; set; }
        public float VibroMultiplier { get; set; }
        public float VibroLengthMultiplier { get; set; }
        public float VibroMaxLength { get; set; }

        // Roll Manipulation
        public float RollRatioToleranceMs { get; set; }
        public float RollRatioMultiplier { get; set; }
        public float RollLengthMultiplier { get; set; }
        public float RollMaxLength { get; set; }

        /// <summary>
        ///     Constructor. Create default strain constant values.
        /// </summary>
        public StrainConstantsKeys()
        {
            // JUMPJACK
            SJackLowerBoundaryMs = NewConstant("SJackLowerBoundaryMs", 40);
            SJackUpperBoundaryMs = NewConstant("SJackUpperBoundaryMs", 320);
            SJackMaxStrainValue = NewConstant("SJackMaxStrainValue", 70);
            SJackCurveExponential = NewConstant("SJackCurveExponential", 1.13f);

            // CHORDJACK
            TJackLowerBoundaryMs = NewConstant("TJackLowerBoundaryMs", 40);
            TJackUpperBoundaryMs = NewConstant("TJackUpperBoundaryMs", 330);
            TJackMaxStrainValue = NewConstant("TJackMaxStrainValue", 60);
            TJackCurveExponential = NewConstant("TJackCurveExponential", 1.15f);

            // Trill
            TrillLowerBoundaryMs = NewConstant("TrillLowerBoundaryMs", 30);
            TrillUpperBoundaryMs = NewConstant("TrillUpperBoundaryMs", 230);
            TrillMaxStrainValue = NewConstant("TrillMaxStrainValue", 80);
            TrillCurveExponential = NewConstant("TrillCurveExponential", 1.15f);

            // Jump
            JumpLowerBoundaryMs = NewConstant("JumpLowerBoundaryMs", 30);
            JumpUpperBoundaryMs = NewConstant("JumpUpperBoundaryMs", 230);
            JumpMaxStrainValue = NewConstant("JumpMaxStrainValue", 60);
            JumpCurveExponential = NewConstant("JumpCurveExponential", 1.13f);

            // Hand
            HandLowerBoundaryMs = NewConstant("HandLowerBoundaryMs", 30);
            HandUpperBoundaryMs = NewConstant("HandUpperBoundaryMs", 230);
            HandMaxStrainValue = NewConstant("HandMaxStrainValue", 40);
            HandCurveExponential = NewConstant("HandCurveExponential", 1.15f);

            // Roll
            RollLowerBoundaryMs = NewConstant("RollLowerBoundaryMs", 30);
            RollUpperBoundaryMs = NewConstant("RollUpperBoundaryMs", 230);
            RollMaxStrainValue = NewConstant("RollMaxStrainValue", 80);
            RollCurveExponential = NewConstant("RollCurveExponential", 1.19f);

            // Bracket
            BracketLowerBoundaryMs = NewConstant("BracketLowerBoundaryMs", 30);
            BracketUpperBoundaryMs = NewConstant("BracketUpperBoundaryMs", 230);
            BracketMaxStrainValue = NewConstant("BracketMaxStrainValue", 56);
            BracketCurveExponential = NewConstant("BracketCurveExponential", 1.13f);

            // LN
            LnBaseMultiplier = NewConstant("LnBaseMultiplier", 0.2f);
            LnLayerToleranceMs = NewConstant("LnLayerToleranceMs", 60f);
            LnLayerThresholdMs = NewConstant("LnLayerThresholdMs", 93.7f);
            LnReleaseAfterMultiplier = NewConstant("LnReleaseAfterMultiplier", 1.0f);
            LnReleaseBeforeMultiplier = NewConstant("LnReleaseBeforeMultiplier", 1.3f);
            LnTapMultiplier = NewConstant("LnTapMultiplier", 1.05f);

            // LongJack Manipulation
            VibroActionDurationMs = NewConstant("VibroActionDurationMs", 88.2f);
            VibroActionToleranceMs = NewConstant("VibroActionToleranceMs", 88.2f);
            VibroMultiplier = NewConstant("VibroMultiplier", 0.75f);
            VibroLengthMultiplier = NewConstant("VibroLengthMultiplier", 0.3f);
            VibroMaxLength = NewConstant("VibroMaxLength", 6);

            // Roll Manipulation
            RollRatioToleranceMs = NewConstant("RollRatioToleranceMs", 2);
            RollRatioMultiplier = NewConstant("RollRatioMultiplier", 0.25f);
            RollLengthMultiplier = NewConstant("RollLengthMultiplier", 0.6f);
            RollMaxLength = NewConstant("RollMaxLength", 14);
        }
    }
}
